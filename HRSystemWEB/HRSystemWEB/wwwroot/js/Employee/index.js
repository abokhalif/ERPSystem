//$(function () {
//    $(document).load(
//        $.ajax({
//            url: '/Employee/Employee/GetAllData', // Ensure this URL is correct
//        type: 'GET',
//            success: function (response) {
//                // Parse the stringified JSON from response.data
//                var parsedResponse = JSON.parse(response.data);  // response.data is a string
//                var employees = parsedResponse.data;
//            var table = $('#employeeTable tbody');
//            table.empty(); // Clear the table before adding new rows
//                employees.forEach(function (employee) {
//                var row = `
//                    <tr>
//                        <td>${employee.id}</td>
//                        <td>${employee.firstName}</td>
//                        <td>${employee.lastName}</td>
//                        <td>${employee.country}</td>
//                        <td>${employee.nationalId}</td>
//                        <td>${new Date(employee.hireDate).toISOString().split('T')[0]}</td>
//                        <td>${employee.salary}</td>
//                        <td>${employee.arrivalTime}</td>
//                        <td>${employee.leaveTime}</td>
//                        <td>${employee.deptName}</td>
//                    </tr>`;
//                table.append(row);
//            })
//        },
//        error: function (xhr) {
//            console.log(xhr);
//            $('#employeeTable tbody').append('<tr><td colspan="10">Error loading data</td></tr>');
//        },
//        })
//    )


    
    
//});
$(function () {
    // General method for loading data into a table
    function loadTable(url, tableId, columns) {
        $.ajax({
            url: url,
            type: 'GET',
            success: function (response) {
                var parsedResponse = JSON.parse(response.data);  // Parse JSON response
                var data = parsedResponse.data;
                var table = $(tableId + ' tbody');
                table.empty(); // Clear the table before adding new rows

                // Loop through the data and dynamically create rows
                data.forEach(function (item) {
                    var row = '<tr>';
                    columns.forEach(function (col) {
                        row += `<td>${item[col]}</td>`;  // Use column name to access the data
                    });
                    row += '</tr>';
                    table.append(row);
                });

                // Destroy any existing DataTable instance before reinitializing
                if ($.fn.DataTable.isDataTable(tableId)) {
                    $(tableId).DataTable().clear().destroy();
                }

                // Initialize DataTable with pagination, sorting, etc.
                $(tableId).DataTable({
                    paging: true,
                    searching: true,
                    ordering: true,
                    pageLength: 10,
                    lengthMenu: [5, 10, 25, 50]
                });
            },
            error: function (xhr) {
                console.error(xhr);
                $(tableId + ' tbody').append('<tr><td colspan="10">Error loading data</td></tr>');
            }
        });
    }

    // Example usage of the loadTable function
    loadTable('/Employee/Employee/GetAllData', '#employeeTable', [
        'id',
        'firstName',
        'lastName',
        'country',
        'nationalId',
        'hireDate',
        'salary',
        'arrivalTime',
        'leaveTime',
        'deptName'
    ]);
});
