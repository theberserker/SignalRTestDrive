﻿//based on https://github.com/SignalR/SignalR/wiki/QuickStart-Persistent-Connections
$(function () {
    var connection = $.connection('/echo');

    connection.received(function (data) {
        if (data) {
            var source = $("#realtime-template").html();
            var template = Handlebars.compile(source);
            var html = template(data);
            $('#realtimeConnectionsContainer').html(html);

        } else {
            alert("No data recieved!");
        }
    });

    connection.start()
        .done(function (conn) {
            console.log('Client connected to ChatHub. Connection ID=' + conn.id);
        })
        .fail(function (error) { console.log('Could not connect to ChatHub. Error:' + error); });
});