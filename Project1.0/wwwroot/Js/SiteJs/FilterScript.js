
function filterTable(category) {
    var rows = document.getElementsByClassName('table-row');
    var table = document.getElementById('animalTable');

    if (category === 'All') {
        for (var i = 0; i < rows.length; i++) {
            rows[i].style.display = 'table-row';
        }
    } else {
        for (var i = 0; i < rows.length; i++) {
            var currentCategory = rows[i].getElementsByTagName('td')[2].innerText;
            if (currentCategory === category) {
                rows[i].style.display = 'table-row';
            } else {
                rows[i].style.display = 'none';
            }
        }
    }
}


var searchInput = document.getElementById('searchInput');
searchInput.addEventListener('input', function () {
    var searchValue = this.value.toLowerCase();
    var tableRows = document.getElementsByClassName('table-row');

    for (var i = 0; i < tableRows.length; i++) {
        tableRows[i].style.display = 'none';
    }

    if (searchValue === '') {
        for (var i = 0; i < tableRows.length; i++) {
            tableRows[i].style.display = 'table-row'; 
        }
    } else {
        for (var i = 0; i < tableRows.length; i++) {
            var animalName = tableRows[i].getElementsByTagName('td')[1].innerText.toLowerCase();

            if (animalName.includes(searchValue)) {
                tableRows[i].style.display = 'table-row';
            }
        }
    }
});


