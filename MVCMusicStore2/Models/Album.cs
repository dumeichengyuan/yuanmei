using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStore2.Models
{
    //绑定 列出将在请求参数绑定到模型的时候，包含和不包含的字段
    [Bind(Exclude="AlbumId")]
    public class Album
    {
        //增加显示和验证的DataAnnotation
        //支架列，在编辑表单时，需要隐藏起来的字符
        //[ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        //显示名——定义表单字段的提示名称
        [DisplayName("Genre")]
        public int GenreId { get; set; }
        
        [DisplayName("ArtistId")]
        public int ArtistId { get; set; }
        
        [DisplayName("Album url Name")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        //必须——表示这个属性是必须提供内容的字段
        //范围——为数字类型提供最大值和最小值
        [Required(ErrorMessage ="An Album Title id required")]
        [StringLength(160)]
        public string Title { get; set; }
            
        [Required(ErrorMessage ="Price id required")]
        [Range(0.01,100.00,ErrorMessage ="Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; } 
        public Genre Genre { get; set; }
        public Artist Artist{get;set;}
    }
}