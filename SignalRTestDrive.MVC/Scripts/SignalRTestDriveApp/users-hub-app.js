$(function () {
    // Declare a proxy to reference the hub. 
    var usersHub = $.connection.usersHub;

    // Create a function that the hub can call to broadcast messages.
    usersHub.client.broadcastState = function (data) {
        if (data) {
            var source = $("#realtime-template").html();
            var template = Handlebars.compile(source);
            var html = template(data);
            $('#realtimeConnectionsContainer').html(html);

        } else {
            alert("No data recieved!");
        }
    };

    $.connection.hub.logging = true;
    $.connection.hub.start()
        .done(function (conn) {
            console.log('Client connected to ChatHub. Connection ID=' + conn.id);
        })
        .fail(function (error) { console.log('Could not connect to ChatHub. Error:' + error); });

}());