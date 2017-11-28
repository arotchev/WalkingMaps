using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WalkingMaps.Entities;

namespace WalkingMaps.Infrastructure
{
    public static class DbInitializer
    {
        private static WalkingMapsDBContext _context;
        private static IServiceProvider _serviceProvider;
        private static UserManager<User> _userManager;
        private static RoleManager<IdentityRole> _roleManager;

        public static void Initialize(IServiceProvider serviceProvider, string resourcesPath)
        {
            _userManager = (UserManager<User>)serviceProvider.GetService(typeof(UserManager<User>));
            _roleManager = (RoleManager<IdentityRole>)serviceProvider.GetService(typeof(RoleManager<IdentityRole>));
            _context = (WalkingMapsDBContext)serviceProvider.GetService(typeof(WalkingMapsDBContext));
            _serviceProvider = serviceProvider;

            InitializeUserRoles();
            InitializeWalks();
            InitializeSights();
           // InitializePhotos(resourcesPath);
            InitializeRoutes();
            AssignSightToWalk();
            
        }

        private static void AssignSightToWalk()
        {
            if (!_context.WalkSights.Any())
            {


                var _walks = _context.Walks.ToList();
                var _sights = _context.Sights.ToList();

                _context.WalkSights.AddRange(new WalkSight[] {
                    new WalkSight() {
                        WalkId = _walks[0].Id,
                        SightId = _sights[0].Id,
                         UserId = _walks[0].UserId
                    },
                    new WalkSight() {
                       WalkId = _walks[0].Id,
                        SightId = _sights[1].Id,
                         UserId = _walks[0].UserId
                    },
                    new WalkSight() {
                        WalkId = _walks[0].Id,
                        SightId = _sights[2].Id,
                         UserId = _walks[0].UserId
                    },
                    new WalkSight() {
                        WalkId = _walks[0].Id,
                        SightId = _sights[3].Id,
                        UserId = _walks[0].UserId
                    },
                     new WalkSight() {
                        WalkId = _walks[0].Id,
                        SightId = _sights[4].Id,
                        UserId = _walks[0].UserId
                    },
                      new WalkSight() {
                        WalkId = _walks[0].Id,
                        SightId = _sights[5].Id,
                        UserId = _walks[0].UserId
                    },
                     new WalkSight() {
                        WalkId = _walks[0].Id,
                        SightId = _sights[6].Id,
                        UserId = _walks[0].UserId
                    },

                     //user 2
                     new WalkSight() {
                        WalkId = _walks[1].Id,
                        SightId = _sights[7].Id,
                         UserId = _walks[1].UserId
                    },
                    new WalkSight() {
                       WalkId = _walks[1].Id,
                        SightId = _sights[8].Id,
                         UserId = _walks[1].UserId
                    },
                    new WalkSight() {
                        WalkId = _walks[1].Id,
                        SightId = _sights[9].Id,
                         UserId = _walks[1].UserId
                    },
                    new WalkSight() {
                        WalkId = _walks[1].Id,
                        SightId = _sights[10].Id,
                        UserId = _walks[1].UserId
                    },
                     new WalkSight() {
                        WalkId = _walks[1].Id,
                        SightId = _sights[11].Id,
                        UserId = _walks[1].UserId
                    },
                      new WalkSight() {
                        WalkId = _walks[1].Id,
                        SightId = _sights[12].Id,
                        UserId = _walks[1].UserId
                    },
                     new WalkSight() {
                        WalkId = _walks[1].Id,
                        SightId = _sights[13].Id,
                        UserId = _walks[1].UserId
                    }


                  });

                _context.SaveChanges();
            }
        }

        private static void InitializeUserRoles()
        {
            string[] roles = new string[] { "Administrator", "Registered" };

            foreach (string role in roles)
            {
                if (!_context.Roles.Any(r => r.Name == role))
                {                   
                    var result =  _roleManager.CreateAsync(new IdentityRole(role)).Result;
                }
            }

            string[] userNames = new string[] { "alex", "bob", "admin" };

            foreach (string userName in userNames)
            {
                
                if (!_context.Users.Any(r => r.UserName == userName))
                {
                    var user = new User()
                    {
                        UserName = userName
                    };
                   
                    var result = _userManager.CreateAsync(user, "Pa55w0rd#").Result;
                }
            }

            

            AssignRole(userNames[2], roles[0]);            
            AssignRole(userNames[0], roles[1]);            
            AssignRole(userNames[1], roles[1]);

            _context.SaveChanges();           
           
        }

        public static void AssignRole(string userName, string roleName)
        {          
            User user = _userManager.FindByNameAsync(userName).Result;         
            var result = _userManager.AddToRoleAsync(user, roleName).Result;
        }

        private static void InitializeWalks()
        {
            if (!_context.Walks.Any())
            {
              
                
                User user = _userManager.FindByNameAsync("admin").Result;

                var _walk1 = _context.Walks.Add(
                    new Walk
                    {

                        Name = "Nice Walk 1",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        StartPoint = "metro Kuzminki",
                        EndPoint = "metro Kitai gorod",
                        CreatedDate = DateTime.Now,
                        Distance = 5.7m,
                        IsPublished = false,
                        UserId = user.Id,
                        City = City.Moscow,
                        
                    }).Entity;

             
                User user2 = _userManager.FindByNameAsync("alex").Result;

                var _walk2 = _context.Walks.Add(
                    new Walk
                    {

                        Name = "Very Nice Walk 2",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        StartPoint = "metro Mayakovskya",
                        EndPoint = "metro Smolenskaya",
                        CreatedDate = DateTime.Now,
                        Distance = 2.7m,
                        IsPublished = false,
                        UserId = user2.Id,
                        City = City.Moscow
                    }).Entity;

                _context.SaveChanges();
            }
        }

        private static void InitializeRoutes()
        {
            if (!_context.Routes.Any())
            {
                Route r1 = new Route();

                Point p1 = new Point
                {
                    Latitude = 37.581286,
                    Longitude = 55.760787
                };
                Point p2 = new Point
                {
                    Latitude = 37.581286,
                    Longitude = 55.760787
                };
                Point p3 = new Point
                {
                    Latitude = 37.581286,
                    Longitude = 55.760787
                };

                r1.Points.Add(p1); r1.Points.Add(p2); r1.Points.Add(p3);

                Route r2 = new Route();

                Point p4 = new Point
                {
                    Latitude = 37.581286,
                    Longitude = 55.760787
                };
                Point p5 = new Point
                {
                    Latitude = 37.581286,
                    Longitude = 55.760787
                };
                Point p6 = new Point
                {
                    Latitude = 37.581286,
                    Longitude = 55.760787
                };

                r2.Points.Add(p4); r2.Points.Add(p5); r2.Points.Add(p6);              

                var _walks = _context.Walks.ToList<Walk>();
                _walks[0].Route = r1;
                _walks[1].Route = r2;
              

                _context.SaveChanges();
            }
        }

        private static void InitializeSights()
        {
            if (!_context.Sights.Any())
            {

                var _walks = _context.Walks.ToList<Walk>();

                foreach (var sight in _context.Sights)
                {

                    sight.UserId = _walks[0].UserId;
                }               

                _context.SaveChanges();
            }

        }

        //private static void InitializePhotos(string imagesPath)
        //{
        //    //if (!_context.Photos.Any())
        //    //{

        //        string[] _images = Directory.GetFiles(Path.Combine(imagesPath, "images"));
        //        var _sights = _context.Sights.ToList<Sight>();
        //        Random rm = new Random();

        //        foreach (Sight _sight in _sights)
        //        {
                    
        //            string _fileName = Path.GetFileName(_images[rm.Next(1,1000)]);

        //            _sight.PhotoUri = _fileName;                  

        //        }
        //        _context.SaveChanges();
        //    //}
        //}
    }
}
