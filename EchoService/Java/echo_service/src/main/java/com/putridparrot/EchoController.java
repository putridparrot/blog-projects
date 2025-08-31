package com.putridparrot;

import org.springframework.web.bind.annotation.*;

@RestController
public class EchoController {

    @GetMapping("/echo")
    public String echo(@RequestParam(name = "text", defaultValue = "") String text) {
        return String.format("Java Echo: %s", text);
    }

    @GetMapping("/readyz")
    public String readyz() {
        return "READY";
    }

    @GetMapping("/livez")
    public String livez() {
        return "ALIVE";
    }
}