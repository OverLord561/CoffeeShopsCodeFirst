using CoffeeShopsCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CoffeeShopsCodeFirst.BLL.RDL
{
    public class Manager 
    {
        CoffeeShopsRepository repo = new CoffeeShopsRepository();

        public  string UploadPhoto(string userID, HttpPostedFileBase file)
        {
            string res;
            string fileName = Guid.NewGuid().ToString();

            try
            {
                string extension = Path.GetExtension(file.FileName);
                fileName += extension;

                List<string> extensions = new List<string>() { ".png", ".jpg", ".jpeg", ".bmp" };
                if (extensions.Contains(extension))
                {

                    file.SaveAs(HttpContext.Current.Server.MapPath("\\Content\\Images\\Uploads\\" + fileName));
                    var FilePath = "\\Content\\Images\\Uploads\\" + fileName;

                    ApplicationUser user = repo.GetUserById(userID);
                    if (user.UserPhoto != null)
                    {
                        string strPhysicalFolder = HttpContext.Current.Server.MapPath("..");
                        string strFileFullPath = strPhysicalFolder + user.UserPhoto;
                        System.IO.File.Delete(strFileFullPath);
                    }
                   
                        user.UserPhoto = FilePath;
                        repo.SaveUserPhoto(user);
                        res = "Файл сохранен";
                    
                }
                else
                {
                    res = "Ошибка. Допустимые расширения файлов - '.png', .jpg','.jpeg','.bmp' ";
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            
            return res;
        }
    }
}