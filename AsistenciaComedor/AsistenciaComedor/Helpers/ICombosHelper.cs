using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AsistenciaComedor.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboNivel();
    }
}