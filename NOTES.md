### Implementation Notes

- Some basic constraints have been placed on the fields on Product:
    - Name can't be longer than 63 characters
    - Description can't be longer than 1024 characters

- Price is a decimal in C# (mapped to decimal(18, 2) in SQL)

- Database calls are done via a product service (accessed via DI) rather than directly in controllers

- The database is seeded with a selection of products if there are none on application startup

- Filtering by minimum and maximum price and stock are available

- The UI has some basic bootstrap styling applied

### Improvements

- Unit test methods ProductsService
- E2E test controller methods
- Min/max filters could be improved using a double slider
- General UI improvements (styling could be better, some form of state tracking across operations, probably would reduce to a single page)
- Most UI elements likely break if input is too long (both text elements and number of products; paging would be ideal)
- Active filter should be 3 state (active/inactive/both)
