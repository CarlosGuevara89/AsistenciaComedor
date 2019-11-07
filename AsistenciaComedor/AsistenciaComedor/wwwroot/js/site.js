$(document).ready(function () {
    //Cargar dataTable
    $('#MyTable').DataTable();


    //Habilitar el datapicker
    $('#mydatetimepicker').datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        todayHighlight: true
    });

    //Pasar a datos a un post
    $('.asistencia').click((e) => {
        var Id = e.currentTarget.dataset.id;
        var fecha = $('#fecha').val();
      
        $.ajax({
            method: "POST",
            url: "/Asistencia/AddAsistencia",
            data: { id: Id, fecha: fecha },
            success: function (data) {
                sweetAlert("Guarado con exito");
            }
         })
    });
   
});