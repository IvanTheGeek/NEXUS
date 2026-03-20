# Order Processing Example

This example shows how software-specific meanings sit on top of the NEXUS base layer.

## Write side node set
- Interface
- Command
- Event

Example:
- Interface: Checkout Form
- Command: PlaceOrder
- Event: OrderPlaced

## Read side node set
- Event
- View
- Interface

Example:
- Event: OrderPlaced
- View: OrderStatusView
- Interface: Customer Web Page

## Important

This does NOT imply a single combined chain.
