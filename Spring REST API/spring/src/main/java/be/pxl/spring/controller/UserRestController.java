package be.pxl.spring.controller;

import java.util.Collection;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import be.pxl.spring.domain.User;
import be.pxl.spring.service.UserService;

@RestController
@RequestMapping(value="/user", produces="application/json")
public class UserRestController {
	//LazyLoading is enabled, use UserSessionRestController if you want to include the user sessions
	
	@Autowired
	UserService us;
	
	
	@RequestMapping(method = RequestMethod.GET, value="{id}")
	public ResponseEntity<User> getUserById(@PathVariable("id") int id){
		// need to explicitly set Sessions to null or the Json serializer will load the Sessions despite lazy loading
		HttpStatus status;
		User u = us.findOne(id);
		if(u == null){
			status = HttpStatus.NOT_FOUND;		
		}else{
			u.setSessions(null);	
			status = HttpStatus.OK;
		}
		return new ResponseEntity<User>(u, status);
	}
	@RequestMapping(method = RequestMethod.GET, value="all")
	public ResponseEntity<List<User>> getAllUsers(){
		HttpStatus status;
		List<User> userList = us.findAll();
		if(userList == null){
			status = HttpStatus.NOT_FOUND;		
		}else{
			this.removeSessions(userList);
			status = HttpStatus.OK;
		}
		return new ResponseEntity<List<User>>(userList, status);
	}
	@RequestMapping(method = RequestMethod.GET, value="ByRole/{role}")
	public ResponseEntity<List<User>> getUsersByRole(@PathVariable("role") String role){
		HttpStatus status;
		List<User> userList = us.findByRole(role);
		if(userList == null){
			status = HttpStatus.NOT_FOUND;		
		}else{
			this.removeSessions(userList);
			status = HttpStatus.OK;
		}
		return new ResponseEntity<List<User>>(userList, status);
	}
	@RequestMapping(method= RequestMethod.GET)
	public String hello()
	{
		return "hello";
	}
	@RequestMapping(method = RequestMethod.GET, value="ByName/{name}")
	public ResponseEntity<List<User>> getUsersByName(@PathVariable("name") String name){
		HttpStatus status;
		List<User> userList = us.findByName(name);
		if(userList == null || userList.isEmpty()){
			status = HttpStatus.NOT_FOUND;		
		}else{
			this.removeSessions(userList);
			status = HttpStatus.OK;
		}
		return new ResponseEntity<List<User>>(userList, status);
	}
	@RequestMapping(method = RequestMethod.GET, value="ByDepartment/{department}")
	public  ResponseEntity<List<User>> getUsersByDepartment(@PathVariable("department") String department){
		HttpStatus status;
		List<User> userList = us.findByDepartment(department);
		if(userList == null || userList.isEmpty()){
			status = HttpStatus.NOT_FOUND;		
		}else{
			this.removeSessions(userList);
			status = HttpStatus.OK;
		}
		return new ResponseEntity<List<User>>(userList, status);
	}
	
	@RequestMapping(method = RequestMethod.POST)
	public int updateUser(@RequestBody User u){
		us.save(u);
		us.flush();
		return u.getUserId();
		
	}
	
	@RequestMapping(method = RequestMethod.DELETE)
	public void deleteUser(@RequestBody User u){
		us.delete(u);
	}
	
	@RequestMapping(method = RequestMethod.POST, value="{id}/{pw}")
	public Boolean login(@PathVariable("id") int id, @PathVariable("pw") String pw){
		User user = us.findOne(id);
		if(us != null && user.getPassword().equals(pw))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	@RequestMapping(method = RequestMethod.POST, value="werkgever/{id}/{pw}")
	public Boolean loginWerkgever(@PathVariable("id") int id, @PathVariable("pw") String pw){
		User user = us.findOne(id);
		if(user != null && user.getPassword().equals(pw) && user.getRole() == "admin")
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	private void removeSessions(Collection<User> users){
		for (User user : users) {
			user.setSessions(null);
		}
	}
}
