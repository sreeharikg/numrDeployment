using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class CompanyDetails
    {
      public string Id { get; set; }
      public string Name { get; set; }
      public string Address { get; set; }
      public string City { get; set; }
      public string Pincode { get; set; }
      public string Country { get; set; }
      public string State { get; set; }
      public string Created_at { get; set; }
      public string Created_by { get; set; }
      public string Updated_at { get; set; }
      public string Updated_by { get; set; }
      public string Status { get; set; }
      public string Phone { get; set; }
      public string Booking_no { get; set; }
      public string Gst_no { get; set; }
      public byte[] image { get; set; }
      public string imagestr { get; set; }
      public int View_status { get; set; }
      public string isreportheader { get; set; }
      public byte[] Logoimg { get; set; }
      public string OPdlno { get; set; }
      public string IPDlno { get; set; }
      public string Dln_no { get; set; }
      public string code { get; set; }
    }
}
