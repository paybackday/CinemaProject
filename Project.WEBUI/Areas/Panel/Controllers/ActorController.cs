using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Panel.Controllers
{
    public class ActorController : Controller
    {
        ActorRepository _acRep;
        MovieActorRepository _mvRep;
        MovieRepository _mRep;
        
        public ActorController()
        {
            _acRep = new ActorRepository();
            _mvRep = new MovieActorRepository();
            _mRep = new MovieRepository();
        }
        // GET: Panel/Actor
        public ActionResult ActorList()
        {
            ActorVM acvm = new ActorVM
            {
                Actors = _acRep.GetActives(),
             MovieActors = _mvRep.GetActives(),
             
                
            };
            return View(acvm);
        }


        public ActionResult MovieActorList( int id)//Filmin oyuncuları gelecek.
        {
            ActorVM avm = new ActorVM
            {
                MovieActors = _mvRep.Where(x => x.ActorID ==id)
            };

            return View();
        }

        public ActionResult AddActor()
        {
            ActorVM avm = new ActorVM
            {
                Actor = new Actor(),
                Movies = _mRep.GetActives(),
            };
            return View(avm);

        }
        [HttpPost]
        public ActionResult AddActor([Bind(Prefix ="Actor")]Actor item)
        {
            _acRep.Add(item);
            return RedirectToAction("ActorList");
        }
        public ActionResult DeleteActor(int id)
        {
            _acRep.Destroy(_acRep.Find(id));
            return RedirectToAction("ActorList");
        }
        public ActionResult UpdateActor(int id)
        {
            ActorVM avm = new ActorVM
            {
                Actor = _acRep.Find(id),
            };
            return View(avm);
        }
        [HttpPost]
        public ActionResult UpdateActor([Bind(Prefix ="Actor")]Actor item)//TODO: AktorID gelmıyor.....
        {
            _acRep.Update(item);
            return RedirectToAction("ActorList");
        }
    }
}