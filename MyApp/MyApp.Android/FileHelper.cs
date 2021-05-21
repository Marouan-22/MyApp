using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyApp.Droid
{
    public class FileHelper: IFileHelper
    {
        public string GetFileContent()

        {

            string content;

            AssetManager assets = Android.App.Application.Context.Assets;

            using (StreamReader sr = new StreamReader(assets.Open("info_text.txt")))

            {

                content = sr.ReadToEnd();

            }

            return content;

        }
    }
}