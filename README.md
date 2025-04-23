# E-commerce-.Net
I am creating a Ecommerce in .Net and Angular

## Database Model
Below is the entity-relationship diagram of the database. This model serves as the foundation for the backend architecture, enabling us to provide comprehensive e-commerce services.
```
+----------------+         +-----------------+         +---------------+
|     Users      |         |     Orders      |         |    Products   |
+----------------+         +-----------------+         +---------------+
| PK: Id         |<---+    | PK: Id          |         | PK: Id        |
| UserName       |    |    | UserId          |---+     | Name          |
| Email          |    +----| TotalAmount     |   |     | Description   |
| Password       |         | Status          |   |     | Price         |
| Address        |         | CreatedAt       |   |     | Stock         |
| Phone          |         | UpdatedAt       |   |     | CategoryId    |---+
| City           |         +-----------------+   |     +---------------+   |
+----------------+                |              |             ^           |
                                  v              v             |           |
                        +-----------------+    +---------------+           |
                        |   OrderItems    |    |   Payment     |           |
                        +-----------------+    +---------------+           |
                        | PK: Id          |    | PK: Id        |           |
                        | OrderId         |    | OrderId       |           |
                        | ProductId       |----| PaymentMethod |           |
                        | Quantity        |    | Amount        |           |
                        | PriceAtTime     |    | Status        |           v
                        +-----------------+    | TransactionId |    +---------------+
                                               +---------------+    |   Categories   |
                                                      |            +---------------+
                                                      |            | PK: Id        |
                        +-----------------+           |            | Name          |
                        |    Shipping     |           |            | Description   |
                        +-----------------+           |            +---------------+
                        | PK: Id          |           |
                        | OrderId         |<----------+
                        | ShippingAddress |
                        | City            |
                        | Country         |
                        | RecipientName   |
                        | Status          |
                        | TrackingNumber  |
                        +-----------------+
```