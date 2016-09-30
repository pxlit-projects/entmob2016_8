package be.pxl.spring;

import org.springframework.boot.SpringApplication;
import org.springframework.context.*;

import be.pxl.spring.config.*;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
    	ConfigurableApplicationContext ctx = SpringApplication.run(AppConfig.class, args);
        System.out.println( "Hello World!" );
    }
}
