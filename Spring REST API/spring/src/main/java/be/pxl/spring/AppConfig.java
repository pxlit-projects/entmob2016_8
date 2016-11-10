package be.pxl.spring;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;

//import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
//import org.springframework.context.annotation.*;
//
//import be.pxl.spring.domain.User;


@SpringBootApplication
@EnableGlobalMethodSecurity(securedEnabled=true)
public class AppConfig {

//	@Bean
//    public User transferService() {
//        return new User();
//    }
	
}
