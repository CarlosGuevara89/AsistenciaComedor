using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;
using AsistenciaComedor.Data;

namespace AsistenciaComedor.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboNivel()
        {
            var list = _dataContext.Niveles.Select(n => new SelectListItem
            {
                Text = n.nombreNivel,
                Value = $"{n.Id}"
            })
                .OrderBy(n => n.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un nivel...)",
                Value = "0"
            });

            return list;
        }
    }
}
