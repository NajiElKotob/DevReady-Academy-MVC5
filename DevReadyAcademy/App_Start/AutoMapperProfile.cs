using AutoMapper;
using DevReadyAcademy.Models;
using DevReadyAcademy.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.App_Start
{
    //AutoMapper

    var config = new MapperConfiguration(cfg => {
        cfg.CreateMap<Course, CourseDTO>();
    });

    IMapper iMapper = config.CreateMapper();
    var c = iMapper.Map<Course, CourseDTO>(course);

}