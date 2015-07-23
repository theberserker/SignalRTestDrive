//based on https://github.com/SignalR/SignalR/wiki/QuickStart-Persistent-Connections
$(function () {
    var connection = $.connection('/echo');

    connection.received(function (data) {
        if (data && Object.prototype.toString.call(data) === '[object Array]') {
            $('#realtimeConnectionsContainer').empty();
            $('#realtimeConnectionsContainer').append('<li>' + JSON.stringify(data) + '</li>');

            //data.forEach(function (currVal, index, array) {
            //    $('#realtimeConnectionsContainer').append("<li>");
            //});
        } else {
            alert("Unknown data format: " + JSON.stringify(data));
        }
    });

    connection.start()
        .done(function (conn) {
            console.log('Client connected to ChatHub. Connection ID=' + conn.id);

            // that was for broadcast messaging example with PersistentConnection
            //$("#broadcast").click(function () {
            //    connection.send($('#msg').val());
            //});
        })
        .fail(function () { console.log('Could not connect to ChatHub'); });
});