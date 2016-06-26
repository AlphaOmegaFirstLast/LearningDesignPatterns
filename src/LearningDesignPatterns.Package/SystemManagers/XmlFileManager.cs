using System;
using System.IO;
using System.Xml;
using LearningBeta08.Package.SystemInterfaces;
using LearningBeta08.Package.SystemModels;

namespace LearningBeta08.Package.SystemManagers
{
    public class XmlFileManager : IXmlFileManager
    {
        public ApiResponse<T> ReadXml<T>(string fileName)
        {
            var response = new ApiResponse<T>();
            string fileSysName =  fileName;
            FileStream fs = null;
            System.Xml.XmlReader reader = null;
            //---------------------------------------------------------------------
            try
            {
                fs = new FileStream(fileSysName, FileMode.Open, FileAccess.Read, FileShare.Read);
                reader = XmlReader.Create(fs);
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T)); //todo use DI for serializer
                var obj = serializer.Deserialize(reader);
                response.Data = (T)obj;
            }
            catch (Exception e)
            {
                response.Status.SetError(-1, "Xml error reading/deserializing file: " + fileSysName, e);
            }
            finally
            {
                reader?.Close();
                fs?.Close();
            }
            return response;
        }

        //----------------------------------------------------------------------------------------------------
        public ApiResponse<T> WriteXml<T>(string fileName, T obj)
        {
            var response = new ApiResponse<T>();
            string fileSysName =fileName;
            FileStream fs = null;
            System.Xml.XmlWriter writer = null;
            //---------------------------------------------------------------------
            try
            {
                System.IO.File.Delete(fileSysName);
                fs = new FileStream(fileSysName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
                writer = XmlWriter.Create(fs);
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
            }
            catch (Exception e)
            {
                response.Status.SetError(-1, "Xml error writting/serializing file: " + fileSysName, e);
            }
            finally
            {
                writer?.Close();
                fs?.Close();
            }
            return response;
        }


    }
}
