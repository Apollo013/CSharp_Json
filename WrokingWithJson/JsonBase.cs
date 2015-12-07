using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;

namespace WrokingWithJson
{
    public abstract class JsonBase<T> : INotifyCollectionChanged
    {

        #region Fields & Properties
        private string fileName = string.Empty;
        private bool hasChanges = false;
        private ObservableCollection<T> list = null;
        #endregion

        #region Properties
        protected Boolean HasChanges
        {
            get
            {
                return this.hasChanges;
            }
        }

        protected ObservableCollection<T> DataItemList
        {
            get
            {
                return list;
            }
            set
            {
                this.list = value;
            }
        }
        #endregion

        #region INotify Collection Changed event & handlers

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnCollectionChanged(NotifyCollectionChangedAction action, T changedItem)
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, changedItem, null));
            }
        }

        protected void OnCollectionChanged(NotifyCollectionChangedAction action, T oldItem, T newItem)
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
            }
        }

        protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var action = e.Action;

            switch (action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Member added\n");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Member replaces\n");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Member removed\n");
                    break;
            }

            hasChanges = true;
        }

        #endregion

        #region Constructor

        public JsonBase(string filename)
        {
            fileName = filename;
            list = new ObservableCollection<T>();                        
            ParseJsonFile();
            list.CollectionChanged += OnCollectionChanged;
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Parses a json file with multiple entries
        /// </summary>
        public abstract void ParseJsonFile();

        /// <summary>
        /// Saves content to a json file
        /// </summary>
        public abstract void SaveJsonFile();

        #endregion

        #region List Methods
        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                var origItem = list[index];
                list[index] = value;
                OnCollectionChanged(NotifyCollectionChangedAction.Replace, origItem, value);
            }
        }

        public void Add(T item)
        {
            list.Add(item);
            OnCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }

        public void Remove(T item)
        {
            list.Remove(item);
            OnCollectionChanged(NotifyCollectionChangedAction.Remove, item);
        }

        public void List()
        {
            foreach (T p in DataItemList)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("\n");
        }
        #endregion

        #region File IO
        /// <summary>
        /// Reads the contents of a json file
        /// </summary>
        /// <returns></returns>
        protected string ReadFile()
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new NullReferenceException("No File Name Specified");
            }

            string json = string.Empty;
            try
            {
                json = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return json;
        }

        /// <summary>
        /// Writes contents to a json file
        /// </summary>
        protected void WriteFile(string json)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new NullReferenceException("No File Name Specified");
            }

            try
            {
                File.WriteAllText(fileName, json);
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion

    }
}
