using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace FileMonitor.Helpers
{
    public class JsonFileHelper
    {
        private string _filename;

        public T LoadJson<T>(string _path, string filename) where T : new()
        {
            var retorno = default(T);

            CreateIfMissing(_path);

            _filename = _path + filename;

            if (!File.Exists(_filename))
            {
                SaveJson<T>(_path, filename, new T());
            }
            try
            {
                using (StreamReader r = new StreamReader(_filename))
                {
                    string json = r.ReadToEnd();
                    retorno = JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao abrir o arquivo: " + e.Message);
            }
            return retorno;
        }
        public bool SaveJson<T>(string _path, string filename, T _parametro)
        {
            var retorno = true;

            CreateIfMissing(_path);

            _filename = _path + filename;

            try
            {
                //open file stream
                using (StreamWriter file = File.CreateText(_filename))
                {
                    JsonSerializer serializer = new JsonSerializer
                    {
                        Formatting = Formatting.Indented
                    };

                    //serialize object directly into file stream
                    serializer.Serialize(file, _parametro);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro ao gravar o arquivo: " + e.Message);
                retorno = false;
            }

            return retorno;
        }
        public void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
