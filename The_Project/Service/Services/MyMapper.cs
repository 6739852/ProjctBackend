using AutoMapper;
using Common.Dto;
using Repository.Entities;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MyMapper : Profile
    {
        string DirectoryUrl = Environment.CurrentDirectory + "\\Images\\";
        public MyMapper()
        {
            //"1.jpg"  byte[]
            CreateMap<PurchasingGroup, PurchasingGroupDto>().ForMember("Image", s => s.MapFrom(y => convertToByte(y.ImageUrl)));

            CreateMap<PurchasingGroupDto, PurchasingGroup>().ForMember("ImageUrl", s => s.MapFrom(y => y.ImageFile.FileName.ToString()));
        }

        byte[] convertToByte(string s)
        {
            if (s !="")
            {
                byte[] bytes = File.ReadAllBytes(DirectoryUrl+s);

                //=Convert.FromBase64String(s);Convert.ToBase64String(
                return bytes;
            }
            else
                return null;
        }

    }
}
