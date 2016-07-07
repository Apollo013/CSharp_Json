using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace WrokingWithJson.Examples
{
    public class NewtonSoftSerialization<T> : JsonBase<T>
    {

        #region Constructor 

        public NewtonSoftSerialization(string filename)
            :base(filename)
        {}

        #endregion

        #region Json Methods

        /// <summary>
        /// Parses a json file with multiple entries
        /// </summary>
        public override void ParseJsonFile()
        {
            try
            {
                string jsonString = base.ReadFile();
                DataItemList = JsonConvert.DeserializeObject<ObservableCollection<T>>(jsonString);
            }
            catch(NullReferenceException ex)
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

        /// <summary>
        /// Saves content to a json file
        /// </summary>
        public override void SaveJsonFile()
        {
            try
            {
                if (this.HasChanges)
                {
                    string json = JsonConvert.SerializeObject(DataItemList);
                    base.WriteFile(json);
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

        #endregion

    }
}
