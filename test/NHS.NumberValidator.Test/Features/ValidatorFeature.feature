Feature: ValidatorFeature
    Validator for NHS numbers


    Scenario: Validate a Single Valid NHS Number
        Given A single valid NHS Number
        Then NHS Number should be valid

    Scenario: Validate a Single Invalid NHS Number
        Given A single invalid NHS Number
        Then NHS Number should be invalid

    Scenario: Validate a Single Invalid NHS Number which is too short
        Given A single invalid NHS Number which is too short
        Then NHS Number should be invalid

    Scenario: Validate a Single Invalid NHS Number which is null
        Given A single invalid NHS Number which is null
        Then The validator should not accept the input