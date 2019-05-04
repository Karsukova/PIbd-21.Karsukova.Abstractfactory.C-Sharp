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
    public class ReptController : ApiController
    {
        private readonly IReptService _service;
        public ReptController(IReptService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetStoragesLoad()
        {
            var list = _service.GetStoragesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetCustomerOrders(ReptBindingModel model)
        {
            var list = _service.GetCustomerOrders(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveZBIPrice(ReptBindingModel model)
        {
            _service.SaveZBIPrice(model);
        }
        [HttpPost]
        public void SaveStoragesLoad(ReptBindingModel model)
        {
            _service.SaveStoragesLoad(model);
        }
        [HttpPost]
        public void SaveCustomerOrders(ReptBindingModel model)
        {
            _service.SaveCustomerOrders(model);
        }
    }
}
