package be.pxl.spring.config;

import org.springframework.context.annotation.*;

import be.pxl.spring.model.*;

@Configuration
public class AppConfig {

	@Bean
	@Scope("prototype")
	public Session session(){
		return new Session();
	}
	@Bean
	@Scope("prototype")
	public User user(){
		return new User();
	}
	@Bean
	@Scope("prototype")
	public FacebookUser facebookUser(){
		return new FacebookUser();
	}
	@Bean
	@Scope("prototype")
	public SteamUser steamUser(){
		return new SteamUser();
	}
	@Bean
	@Scope("prototype")
	public TwitterUser twitterUser(){
		return new TwitterUser();
	}
}
