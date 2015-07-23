//https://github.com/SignalR/SignalR/wiki/QuickStart-Persistent-Connections
$(function () {
    var connection = $.connection('/echo');

    connection.received(function (data) {
        $('#messages').append('<li>' + data + '</li>');
    });

    connection.start()
        .done(function (conn) {
            console.log('Client connected to ChatHub. Connection ID=' + conn.id);

            $("#broadcast").click(function () {
                connection.send($('#msg').val());
            });
        })
        .fail(function () { console.log('Could not connect to ChatHub'); });
});