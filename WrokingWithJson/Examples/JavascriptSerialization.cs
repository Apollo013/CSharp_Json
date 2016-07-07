using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Web.Script.Serialization;

namespace WrokingWithJson.Examples
{
    public class JavascriptSerialization<T> : JsonBase<T>
    {
        private JavaScriptSerializer serializer = null;

        private JavaScriptSerializer Serializer
        {
            get
            {
                if (serializer == null)
                {
                    serializer = new JavaScriptSerializer();                     
                }
                return serializer;
            }
        }

        public JavascriptSerialization(string filename)
            :base(filename)
        { }

        public override void ParseJsonFile()
        {
            try
            {
                string jsonString = base.ReadFile();
                DataItemList = Serializer.Deserialize<ObservableCollection<T>>(jsonString);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void SaveJsonFile()
        {
            try
            {
                if (this.HasChanges)
                {
                    string jsonString = Serializer.Serialize(DataItemList);
                    this.WriteFile(jsonString);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
