# CarnetAdresse

1) Récupérer la solution en local:
git clone https://github.com/gtb-0310/CarnetAdresse/

2) Dans le shell Mongo, créer la db CarnetAdresse et la collection People:
a. Lancer le shell mongosh
b. Appuyer sur Enter
c. use CarnetAdresse
d. db.createCollection("People")

3) Créer le dossier MongoDB

4) Dans l'invité de commande, rentrer le code:
mongod --dbpath leCheminVersLaDb
(exemple: mongod --dbpath C:\Users\jnaga\Desktop\MongoDB)
Et laisser l'invité de commande ouvert durant l'utilisation de l'application!

5) Avant de run l'application, s'assurer que l'Api et le projet UWP run au démarrage: dans l'explorateur de solutions, clic droit sur la solution ==> gérer les projets de démarrage ==> cocher "BookStoreApi" et "CarnetAdresseXamarin"

6) Pour les tests d'intégration, il est important de récupérer l'ID d'une des entrées de la DB en brut!