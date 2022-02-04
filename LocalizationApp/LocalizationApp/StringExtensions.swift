//
//  StringExtensions.swift
//  LocalizationApp
//
//  Created by Mark Timmings on 04/02/2022.
//

import Foundation

extension String {
   func localize() -> String {
      return NSLocalizedString(self, comment: self)
   }
}
