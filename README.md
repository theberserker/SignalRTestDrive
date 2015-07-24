This is very basic example project for SignalR. The application is created on default ASP.NET MVC 5 Template with Authentication.

Project currently consists of three examples:
- Chat
- Connected users (PersistentConnection)
- Connected users (Hub)

##Chat
Is trivial, mostly copy-paste example from the official SignalR tutorial. It only adds the name from a login, if there is one. It is a *Hub* implementation.

##Connected users
Is simple connected sessions tracker and has two implementations - with `PersistentConnection` and `Hub`.
It displays realtime when different users get connected.
When users connect or disconnect this is tracked by `ConnectedUsersManager` and manager is using a `ConnectedUsersRepository` to store information about connected users.

Both (*PersistentConnection* and *Hub* implementations) are populating same, in-memory repository, but realtime update is done only the implementation of the kind that caused change. I.e. if Hub implementation (*/Home/ConnectedUsersHub*) is opened in new tab only only all sites on this site get realtime update.
