# Exercises


## Exercise 1

### Corrections de Bugs

1- Si vous exécutez le projet et que vous essayez d'ajouter un nouveau livre avec la requête suivante :

`[Post] api/book/add {"title" : "Book 6", "author": "Author 6" }`

une erreur sera levée. Identifiez le bug et corrigez-le.

------------------------------------------------------------------

2 - Si vous ajoutez un nouveau livre avec la requête suivante : 

- `[Post] api/book/add { "title" : "Book 6", "author": "Author 5" }`
- `[Get] api/books`

Vérifiez la réponse, le livre est-il ajouté avec succès ? Si non, identifiez le bug et corrigez-le.


## Exercise 2

### Appliquer ces regles pour l'ajout d'un livre
1 - Le titre du livre doit être unique par auteur. Si un livre avec le même titre existe déjà, une erreur doit être renvoyée.
2 - Le titre du livre doit contenir au moins 3 caractères.


## Exercise 3

### Implémenter une nouvelle fonctionalité


1- Implémentez cette méthode de bout en bout : Obtenez les clients qui ont emprunté des livres et exposez-la via un endpoint approprié (customers-who-borrowed-books).
	Conforme aux standards de production.

2- Implémentez des tests unitaires pour cette méthode.


------------------------------------------------------------------