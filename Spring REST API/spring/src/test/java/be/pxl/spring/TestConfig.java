package be.pxl.spring;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import be.pxl.spring.service.SessionUtility;

@Configuration
public class TestConfig {
@Bean
public SessionUtility su(){
	return new SessionUtility();
}
}
