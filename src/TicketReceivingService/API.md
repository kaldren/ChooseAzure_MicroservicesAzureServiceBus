# Ticket Receiving Service (TSI) API

This document describes the TSI API available endpoints and their usage.

## Create a new ticket
### Request details
- **Method**: POST
- **Endpoint**: /tickets
- **Content-Type**: application/json
- **Accept-Language**: en-US,en;q=0.5

### Payload

The request payload should be a JSON object with the following fields:

```json
{
  "Title": "Ticket Title",
  "Description": "Ticket Description",
  "Email": "johndoe@example.com",
  "Phone": "1234567890"
}
```