Feature: Restaurant Checkout System


  @checkout
  Scenario: Group of 4 orders 4 starters, 4 mains, and 4 drinks
    Given a group of 4 people places an order:
      | Item      | Quantity | Time  |
      | Starter   | 4        | 20:00 |
      | Main      | 4        | 20:00 |
      | Drink     | 4        | 20:00 |
    When the bill is requested
    Then the total bill should be 58.40

  @checkout
  Scenario: Group of 2 orders, later joined by 2 more
    Given a group of 2 orders:
      | Item      | Quantity | Time  |
      | Starter   | 1        | 18:30 |
      | Main      | 2        | 18:30 |
      | Drink     | 2        | 18:30 |
    When they request the bill
    Then the total bill should be 23.30
    Given 2 more people join at 20:00
    And they order:
      | Item  | Quantity | Time  |
      | Main  | 2        | 20:00 |
      | Drink | 2        | 20:00 |
    When the final bill is requested
    Then the total bill should be 43.70

  @checkout
  Scenario: A group of 4 orders, but 1 cancels
    Given a group of 4 people places an order:
      | Item      | Quantity | Time  |
      | Starter   | 4        | 20:00 |
      | Main      | 4        | 20:00 |
      | Drink     | 4        | 20:00 |
    When one member cancels their order
    Then the bill should be updated to 49.50