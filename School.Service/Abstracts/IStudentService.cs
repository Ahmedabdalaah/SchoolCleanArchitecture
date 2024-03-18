﻿using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Abstracts
{
    public interface IStudentService
    {
        public Task <List<Student>> GetStudentsAsync();
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddStudentAsunc(Student student);


    }
}
