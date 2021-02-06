using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PBDesk
{
    public class Parser
    {
        public const Byte MODE_FILE = 0, MODE_STRING = 1;

        private XmlDocument document;
        private Byte mode;

        public Parser(Byte mode)
        {
            this.document = new XmlDocument();
            this.mode = mode;
        }

        public Parser(Byte mode, in String document, bool incorrect = false)
        {
            this.document = new XmlDocument();
            this.mode = mode;

            if (this.mode == Parser.MODE_FILE)
                this.LoadDocument(document);
            else if (this.mode == Parser.MODE_STRING)
                if (incorrect)
                    this.LoadIncorrectString(document);
                else
                    this.LoadString(document);
        }

        public String Text { get => this.document.InnerXml; private set => this.LoadString(value); }

        public void LoadDocument(in String document)
        {
            this.document.Load(document);
        }

        public void LoadString(in String document)
        {
            this.document.LoadXml(document);
        }

        public void LoadIncorrectString(in String document)
        {
            this.document.LoadXml("<tempxmldoc>" + document + "</tempxmldoc>");
        }

        public String GetParameter(in String path)
        {
            return this.document.SelectSingleNode(path).InnerText;
        }

        public List<String> GetParameters(String path)
        {
            List<String> list = new List<String>();
            XmlNodeList nodes = this.document.SelectNodes(path);

            if (nodes != null)
                if (nodes.Count > 0)
                    foreach (XmlNode node in nodes)
                        list.Add(node.OuterXml);

            return list;
        }

        public void WriteToFile(in String full_path, in String dev_key)
        {
            if (File.Exists(full_path))
                File.Delete(full_path);

            using (FileStream file_stream = new FileStream(full_path, FileMode.Create))
            {
                using (Aes aes = Aes.Create())
                {
                    Byte[] key = Encoding.UTF8.GetBytes(dev_key);
                    aes.Key = key;
                    Byte[] iv = aes.IV;
                    file_stream.Write(iv, 0, iv.Length);

                    using (CryptoStream crypto_stream =
                        new CryptoStream(file_stream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        using (StreamWriter stream_writer = new StreamWriter(crypto_stream))
                        {
                            stream_writer.WriteLine(this.Text);
                        }
                    }
                }
            }
        }

        public void ReadFromFile(in String full_path, in String dev_key)
        {
            if (File.Exists(full_path))
            {
                using (FileStream file_stream = new FileStream(full_path, FileMode.Open))
                {
                    using (Aes aes = Aes.Create())
                    {
                        Byte[] key = Encoding.UTF8.GetBytes(dev_key);
                        aes.Key = key;
                        Byte[] iv = new byte[aes.IV.Length];
                        file_stream.Read(iv, 0, iv.Length);

                        using (CryptoStream crypto_stream =
                            new CryptoStream(file_stream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                        {
                            using (StreamReader stream_reader = new StreamReader(crypto_stream))
                            {
                                this.Text = stream_reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}
