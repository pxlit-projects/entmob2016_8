package be.pxl.spring;

import org.springframework.boot.SpringApplication;
import org.springframework.context.*;

import be.pxl.spring.config.*;
import be.pxl.spring.model.User;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
    	ConfigurableApplicationContext ctx = SpringApplication.run(AppConfig.class, args);
    	User u = ctx.getBean("user", User.class);
    	u.setFirstName("brecht");
        System.out.println( u.getFirstName() );
    }
}
