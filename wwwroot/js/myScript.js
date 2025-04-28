 
    $(document).ready(function () {
            // Initialize Tooltips
            const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]');
            const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl));

    // Initialize DataTable
    let table = $('#example').DataTable({
        scrollY: '400px',
    scrollCollapse: true,
    paging: true,
    searching: true,
    ordering: true,
    info: true,
    responsive: true,
    columnDefs: [
    {targets: [5], className: 'text-right' }, // Right-align Cheque Amount
    {
        targets: [5], // Cheque Amount
    render: function (data, type, row) {
                            return data === 'N/A' || data === null || data === '' ? '0.00' : parseFloat(data).toFixed(2);
                        }
                    },
    {
        targets: [4, 8, 11, 14], // Dates
    render: function (data, type, row) {
                            return data === '' || data === null ? '' : data;
                        }
                    }
    ],
    dom: 'Bfrtip',
    buttons: [
    'copy', 'csv', 'excel', 'pdf', 'print'
    ]
            });

    // Row click handler
    table.on('click', 'tbody tr', function (e) {
                if ($(e.target).is('a, button')) return;
    let data = table.row(this).data();
    if (data) {
        let message = `Selected Row Details:\n` +
    `Ledger: ${data[1] || 'N/A'}\n` +
    `Party: ${data[2] || 'N/A'}\n` +
    `Amount: ${data[5] || '0.00'}\n` +
    `Payment Type: ${data[10] || 'N/A'}`;
    alert(message); // Replace with modal in production
                }
            });

    // Chart.js Initialization
    const ctx = document.getElementById('myChart').getContext('2d');
    new Chart(ctx, {
        type: 'line',
    data: {
        labels: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
    datasets: [{
        label: 'Cheque Amounts',
    data: [15339, 21345, 18483, 24003, 23489, 24092, 12034],
    tension: 0.4,
    backgroundColor: 'rgba(42, 82, 152, 0.1)',
    borderColor: '#2a5298',
    borderWidth: 3,
    pointBackgroundColor: '#2a5298',
    pointRadius: 5,
    fill: true
                    }]
                },
    options: {
        responsive: true,
    plugins: {
        legend: {
        display: true,
    position: 'top',
    labels: {
        font: {
        size: 14,
    family: 'Inter'
                                }
                            }
                        }
                    },
    scales: {
        y: {
        beginAtZero: false,
    grid: {
        color: '#e9ecef'
                            },
    ticks: {
        font: {
        size: 12
                                }
                            }
                        },
    x: {
        grid: {
        display: false
                            },
    ticks: {
        font: {
        size: 12
                                }
                            }
                        }
                    }
                }
            });
        });
 