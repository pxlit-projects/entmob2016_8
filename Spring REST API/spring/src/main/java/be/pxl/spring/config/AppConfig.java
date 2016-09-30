package be.pxl.spring.config;

import org.springframework.context.annotation.*;

import be.pxl.spring.model.*;

@Configuration
public class AppConfig {

	@Bean
	public Session session(){
		return new Session();
	}
	@Bean
	public User user(){
		return new User();
	}
	@Bean
	public FacebookUser facebookUser(){
		return new FacebookUser();
	}
	@Bean
	public SteamUser steamUser(){
		return new SteamUser();
	}
	@Bean
	public TwitterUser twitterUser(){
		return new TwitterUser();
	}
}
