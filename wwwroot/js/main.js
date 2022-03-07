// Buscar en Recibo
function searchRecibo() {
    const renglon_tabla = document.getElementById('table-recibo');
    const busqueda = document.getElementById('seeker-recibo').value.toLowerCase();
    let total = 0;

    // Recorrer todas las filas de la tabla
    for (let i = 1; i < renglon_tabla.rows.length; i++)
    {
        let found = false;
        const celdas_renglon = renglon_tabla.rows[i].getElementsByTagName('td');

        // Recorrer solo las celdas en las se buscará (Id / Proveedor)
        for(let j = 0; j <= 1 && !found; j++)
        {
            const comparacion = celdas_renglon[j].innerHTML.toLowerCase();

            // Buscar el texto en el contenido de la celda
            if (busqueda.length == 0 || comparacion.indexOf(busqueda) > -1)
            {
                found = true;
                total++;
            }
            if (found)
            {
                renglon_tabla.rows[i].style.display = '';
            }
            else
            {
                // Si no ha encontrado ninguna coincidencia, esconde la fila de la tabla
                renglon_tabla.rows[i].style.display = 'none';
            }
        }
    }

    // Mostrar las coincidencias
    if(busqueda == "")
    {
        $('#search-recibo-coincidences').css("display", "none");
        $('#search-recibo-coincidences-none').css("display", "none");
    }
    else if (total)
    {
        $('#search-recibo-coincidences-none').css("display", "none");
        $('#search-recibo-coincidences').css("display", "block");
        document.getElementById('search-recibo-coincidences').innerHTML = ((total > 1) ? "Se encontraron " + total + " coincidencias" : "Se encontró " + total + " coincidencia");
    }
    else
    {
        $('#search-recibo-coincidences').css("display", "none");
        $('#search-recibo-coincidences-none').css("display", "block");
        document.getElementById('search-recibo-coincidences-none').innerHTML = "No se han encontrado coincidencias";
    }
}
