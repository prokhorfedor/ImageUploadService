**Overview**

Here you can see three endpoints created according to your specs.
<img width="1469" height="454" alt="image" src="https://github.com/user-attachments/assets/42dcaaa9-ce6a-43fd-af9d-785d9f164038" />

1. Adding pictures for lead
   I've added a lead into the DB (adding Lead endpoint was out of scope so I've done it manually from SQL Studio)
   <img width="1129" height="532" alt="image" src="https://github.com/user-attachments/assets/fdb64a91-9a78-4803-8a3f-23a164aea5f0" />

   Adding two pictures request/response
   <img width="1450" height="672" alt="image" src="https://github.com/user-attachments/assets/fbbd2c13-0f41-4176-9e28-8ca71b934dcd" />



2. Getting pictures for lead request/response
   <img width="1407" height="800" alt="image" src="https://github.com/user-attachments/assets/8573e9e6-e4c3-47c3-b551-d19c8327995b" />

   
   The response is kinda long so I'm making it short to show full contract
   [
    {
      "leadImageId": 3,
      "image": "/9j/4AAQSkZJ....",
      "isDeleted": false,
      "leadId": "b51f6387-aeb7-4d70-9abf-3729b17a8e27"
    }

  ]



3. Deleting image for lead request/response
   <img width="529" height="472" alt="image" src="https://github.com/user-attachments/assets/5e40a70e-4c22-46da-95ee-b9c4842096be" />


**Error Handling**

I have basic error handling for wrong or missing request params, also FileSize limit to 5MB
<img width="600" height="737" alt="image" src="https://github.com/user-attachments/assets/3a4fba41-49cb-4809-ab0f-8e72b916da1e" />

Also I have error handling of limit of images per lead
<img width="674" height="771" alt="image" src="https://github.com/user-attachments/assets/adeb836f-6416-4b6c-b5c3-e92fcadf5018" />

   
 
