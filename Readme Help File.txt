
api url :     http://host/v1/contacts/
description : Gets all the contacts. returns a list of avaliable contacts.

api url :     http://host/v1/GetContactById?contactId=1
description : Gets the contact with the specified id. If contact not found gives approriate message.

api url :     http://host/v1/SaveContact/
description : Saves the contact.Takes a Person object as input. If contact already exists gives approriate message.
              All the fields are mandatory to save a contact. Validations on email id and mobile number.

api url :     http://host/v1/DeleteContact?id=2
description : Deletes the contact with the specified id. If contact doesnt exists gives approriate message.

api url :     http://localhost:60958/v1/UpdateContact
description : Updates the specified contact. If contact doesnt exists gives approriate message.

