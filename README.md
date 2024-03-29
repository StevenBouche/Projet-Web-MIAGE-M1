<h1 align="center"> Projet Web Miage  : Application Discord-like - Angular / .NET</h1>

<h3 align="center"> Adresse pour lancer l'application en ligne: <strong> http://51.210.181.145:4200/ </strong> </h3>
<h3 align="center"> Adresse pour consulter l'API en ligne: <strong> http://51.210.181.145:7000/swagger/ </strong> </h3>
<h3 align="center"> Code pour lancer l'application en local : <strong> cd AngularUI > cd forum-app > npm install > ng serve</strong>

</h3>

<p align="center"><i>Membres : Armand PREVOT - Steven BOUCHE</i></p>
<p align="center"><i>Enseignant : M.Buffa </i></p>

Dans le cadre d'un projet universitaire, nous avons réalisé une application qui ressemble à Discord, surtout sur sa partie forum. Voici la configuration de notre projet :

<ul>
  <li>Le Front est en Angular 10 et les API en C# dans un environnement .NET Core 3.1</li>
  <li>Nous stockons nos données dans plusieurs bases Mongo.</li>
  <li>Notre application est structurée en micro-service.</li>
  <li>Chaque microservice est contenu dans un conteneur Docker.</li>
  <li>Aussi, chaque microservice contient une base Mongo qui lui est propre.</li>
  <li>Microservice d'Authentification OAuth avec Jwt token et refresh token.</li>
  <li>Passerelle d'API qui expose nos microservices.</li>
  <li>Enfin, nous utilisons des WebSocket pour pouvoir gérer les notifications de utilisateurs en temps réel. Le reste des interactions réseau est en HTTP.</li>
  <li>Authentification websocket via le microservice d'Authentification.</li>
</ul>

Voilà ce qu'il est possible de faire avec notre application :
  - Créer un compte
  - Créer des forums
  - Créer des channels de discussion
  - Supprimer des channels de discussion 
  - Créer / envoyer / recevoir des messages dans un channel
  - Visualiser les utilisateurs dans un forum
  - Se connecter / Se déconnecter
  - Rejoindre un forum existant et ses channels
 
 Voilà ce que l'on aurait aimé pouvoir faire/améliorer :
  - Implémenter la suppression de message / forum
  - Améliorer la vérification des formulaires
  - Implémenter la recherche dans les forums / channels / messages
  - Inclure le chat vocal
  - Inclure un système d'amis
  - Inclure des chats privés entre amis
