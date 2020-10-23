 using DataStore.Server.Interfaces;
using DataStore.Server.Models;
using System;
using System.IO;
using System.Text;

namespace DataStore.Server.FileStore
{
    public class FileOperations: IOperations
    {
        private const string filePath = @"E:\Training\daysharpner\soapcore-day1\db.txt";
        public RegisterResponseModel Register(RegisterRequestModel data)
        {
            try
            { 
                File.AppendAllText(filePath, string.Format("{0},{1},{2} \n", data.Id, data.Name, data.EmailId));
                return new RegisterResponseModel()
                { 
                    IsSuccess = true, 
                    Code = 200, 
                    Message = "SUCCESS"
                };
            }
            catch (Exception ex)
            {
                return new RegisterResponseModel(){
                    IsSuccess = false,
                    Code = 500,
                    Message = ex.Message
                };
            }
        }
    }
}
