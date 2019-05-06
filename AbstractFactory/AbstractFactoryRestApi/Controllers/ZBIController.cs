using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AbstractFactoryServiceDAL.BindingModel;
using AbstractFactoryServiceDAL.Interfaces;

namespace AbstractFactoryRestApi.Controllers
{
    public class ZBIController : ApiController
    {
        private readonly IZBIService _service;
        public ZBIController(IZBIService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }
        [HttpPost]
        public void AddElement(ZBIBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(ZBIBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(ZBIBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}