using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ParksClient.Models
{
  public class Detail
  {
    public int DetailId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Rating { get; set; }
    public int ParkId { get; set; } = 0;
    public virtual User User { get; set; }

    public static List<Detail> Get()
    {
      var apiCallTask = DetailApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Detail> detailList = JsonConvert.DeserializeObject<List<Detail>>(jsonResponse.ToString());

      return detailList;
    }

    public static Detail GetDetails(int id)
    {
      var apiCallTask = DetailApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Detail detail = JsonConvert.DeserializeObject<Detail>(jsonResponse.ToString());

      return detail;
    }

    public static void Post(Detail detail)
    {
      string jsonDetail = JsonConvert.SerializeObject(detail);
      var apiCallTask = DetailApiHelper.Post(jsonDetail);
    }

    public static void Put(Detail detail)
    {
      string jsonDetail = JsonConvert.SerializeObject(detail);
      var apiCallTask = DetailApiHelper.Put(detail.DetailId, jsonDetail);
    }

    public static void Delete(int id)
    {
      var apiCallTask = DetailApiHelper.Delete(id);
    }
  }
}
