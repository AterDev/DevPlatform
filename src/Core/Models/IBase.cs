using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public interface IBase
{
    Guid Id { get; }
    DateTimeOffset CreatedTime { get; }
}
