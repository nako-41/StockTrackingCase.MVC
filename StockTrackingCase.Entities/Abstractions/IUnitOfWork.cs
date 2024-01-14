using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingCase.Entities.Abstractions;
public interface IUnitOfWork
{
    int SaveChanges();
}
