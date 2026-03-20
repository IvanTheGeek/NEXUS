# Write / Read Separation

LawId: `nexus.law.write-read-separation`

## Statement

NEXUS modeling is always EITHER write side OR read side, never a combined chain.

## Canonical node sets

### Write side
- Interface
- Command
- Event

### Read side
- Event
- View
- Interface

## Anti-pattern

- Interface -> Command -> Event -> View

## Why this matters

Combining write and read into one chain collapses different concerns and breaks lens separation.

## Notes

Event is the shared node role between the two sides, but the sides remain distinct.
