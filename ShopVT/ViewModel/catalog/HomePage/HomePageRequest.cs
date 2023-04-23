using Microsoft.AspNetCore.Http;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.AccDoc
{
    public class HomePageRequest
    {

        public int Id { set; get; }
        public string Stt { set; get; }
        public string Name { set; get; }
        public string Banner { set; get; }
        public IFormFile BannerImage { set; get; }

        public string BannerUrl { set; get; }
        public string BannerDescription { set; get; }
        public int DisplayOrder { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public string HomePageDetail_Json { set; get; }
        public List<vB10HomePageDetailModel> vB10HomePageDetail_Json { get; set; }

    }
}
