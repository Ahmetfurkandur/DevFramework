﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DependecyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
