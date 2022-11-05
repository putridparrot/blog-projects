//
//  ContentView.swift
//  LocalizationApp
//
//  Created by Mark Timmings on 04/02/2022.
//

import SwiftUI

struct ContentView: View {
    let name = "Scooby Doo"
    let variable = "hello-world".localize()
    
    var body: some View {
        VStack {
            Text("hello-world")
            Text(LocalizedStringKey("hello-world"))
            Text("my-name \(name)")
            Text(variable)
            Spacer()
        }
        .padding()
        .frame(minWidth: 500, minHeight: 300)
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        Group {
            ContentView()
                .environment(\.locale, .init(identifier: "en"))
            ContentView()
                .environment(\.locale, .init(identifier: "fr"))
        }
    }
}
