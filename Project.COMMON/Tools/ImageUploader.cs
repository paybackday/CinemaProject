﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.COMMON.Tools
{
   

    public static class ImageUploader
    {
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file!=null)
            {
                Guid uniqueName = Guid.NewGuid();
             
                serverPath = serverPath.Replace("~", string.Empty); 

            

                string[] fileArray = file.FileName.Split('.'); 

                string extension = fileArray[fileArray.Length - 1].ToLower(); 

                string fileName = $"{uniqueName}.{extension}";
                if (extension=="jpg"||extension=="gif"||extension=="png"||extension=="jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        return "Dosya zaten var";
                    }
                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);

                        file.SaveAs(filePath);

                        return serverPath + fileName;

                    }
                }
                else
                {
                    return "Resim seçilmedi";
                }
            }
            else
            {
                return "Dosya bos";
            }

           
        }
    }
}